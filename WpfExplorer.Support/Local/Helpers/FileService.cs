using Jamesnet.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WpfExplorer.Support.Local.Models;


namespace WpfExplorer.Support.Local.Helpers
{
    public class FileService
    {
        private readonly DirectoryManager _directoryManger;

        public FileService(DirectoryManager diretoryManger)
        {
            _directoryManger = diretoryManger;
        }

        public List<FolderInfo> GenerateRootNodes()
        {
            List<FolderInfo> roots = new()
            {
                createfolderinfo(1,"Download",IconType.ArrowDownBox, _directoryManger.DownloadDirectory),
                createfolderinfo(1,"Documents",IconType.TextBox, _directoryManger.DocumentsDirectory),
                createfolderinfo(1,"Pictures",IconType.Image, _directoryManger.PicturesDirectory),
            };

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                var name = $"{drive.VolumeLabel} ({drive.RootDirectory.FullName.Replace("\\", "")})";
                roots.Add(createfolderinfo(1, name, IconType.MicrosoftWindows, drive.Name));
            }

            return roots;
        }

        private FolderInfo createfolderinfo(int depth, string name, IconType iconType, string fullPath)
        {
            return new FolderInfo
            {
                Depth = depth,
                Name = name,
                IconType = iconType,
                FullPath = fullPath,
                Children = new()
            };
        }

        public void RefreshSubDirectories(FolderInfo parent)
        {
            var newChildren = FetchSubdirectories(parent);

            var oldChildrenDict = parent.Children.ToDictionary(c => c.FullPath);
            var newChildrenDict = newChildren.ToDictionary(c => c.FullPath);

            var added = newChildren.Where(c => !oldChildrenDict.ContainsKey(c.FullPath)).ToList(); //뉴칠드런에서 fullpath를 key로 검색해서 중복된 데이터 리스트화
            var removed = parent.Children.Where(c => !newChildrenDict.ContainsKey(c.FullPath)).ToList(); //parent의children 컬렉션에서 중복된 애들 제거

            parent.Children.AddRange(added);
            foreach (var child in removed)
            {
                parent.Children.Remove(child);
            }
        }
        private static List<FolderInfo> FetchSubdirectories(FolderInfo parent)
        {
            var children = new List<FolderInfo>();
            try
            {
                var subDirs = Directory.GetDirectories(parent.FullPath);
                foreach (var dir in subDirs)
                {
                    children.Add(new FolderInfo
                    {
                        Depth = parent.Depth + 1,
                        Name = Path.GetFileName(dir),
                        IconType = IconType.Folder,
                        FullPath = dir,
                        Children = new()
                    });
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return children;
        }
    }
}
