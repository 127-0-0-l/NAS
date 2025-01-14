using NAS.Logic.DTO;
using NAS.Logic.Managers.Interfaces;
using NAS.Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAS.Logic.Managers.Implementations
{
    public class FileManager : BaseManager, IFileManager
    {
        public List<FileDTO> GetAll()
        {
            return _context.Files.Select(f => EntityToDTO(f)).ToList();
        }

        public FileDTO GetById(int id)
        {
            File file = _context.Files.FirstOrDefault(f => f.Id == id);

            if (file == null)
                return null;

            return EntityToDTO(file);
        }

        public int Add(FileDTO item)
        {
            File newFile = new File
            {
                Name = item.Name,
                Extension = item.Extension,
                Path = item.Path,
                Size = item.Size,
                HashSum = item.HashSum,
                Prewiew = item.Prewiew,
                PrewiewExtension = item.PrewiewExtension,
                IsInTrash = item.IsInTrash,
                ModifiedDateTime = item.ModifiedDateTime,
                LastCheckedDateTime = item.ModifiedDateTime
            };

            if (item.FolderId != null)
            {
                Folder folder = _context.Folders.FirstOrDefault(f => f.Id == item.FolderId);
                newFile.Folder = folder;
            }

            _context.SaveChanges();
            return _context.SaveChanges();
        }

        public bool Remove(int id)
        {
            File file = _context.Files.FirstOrDefault(f => f.Id == id);

            if (file != null)
            {
                _context.Files.Remove(file);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(FileDTO item)
        {
            File file = _context.Files.FirstOrDefault(f => f.Id == item.Id);

            if (file != null)
            {
                file.Name = item.Name;
                file.Extension = item.Extension;
                file.Path = item.Path;
                file.Size = item.Size;
                file.HashSum = item.HashSum;
                file.Prewiew = item.Prewiew;
                file.PrewiewExtension = item.PrewiewExtension;
                file.IsInTrash = item.IsInTrash;
                file.ModifiedDateTime = item.ModifiedDateTime;
                file.LastCheckedDateTime = item.ModifiedDateTime;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public static FileDTO EntityToDTO(File file)
        {
            if (file == null)
                return null;

            return new FileDTO
            {
                Id = file.Id,
                FolderId = file.FolderId,
                Name = file.Name,
                Extension = file.Extension,
                Path = file.Path,
                Size = file.Size,
                HashSum = file.HashSum,
                Prewiew = file.Prewiew,
                PrewiewExtension = file.PrewiewExtension,
                IsInTrash = file.IsInTrash,
                ModifiedDateTime = file.ModifiedDateTime,
                LastCheckedDateTime = file.ModifiedDateTime
            };
        }
    }
}
