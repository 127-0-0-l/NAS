using NAS.Logic.DTO;
using NAS.Logic.Managers.Interfaces;
using NAS.Storage.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NAS.Logic.Managers.Implementations
{
    public class FolderManager : BaseManager, IFolderManager
    {
        public List<FolderDTO> GetAll()
        {
            return _context.Folders.Select(f => EntityToDTO(f)).ToList();
        }

        public FolderDTO GetById(int id)
        {
            Folder folder = _context.Folders.FirstOrDefault(f => f.Id == id);

            if (folder == null)
                return null;

            return EntityToDTO(folder);
        }

        public int Add(FolderDTO item)
        {
            Folder newFolder = new Folder
            {
                Name = item.Name
            };

            if (item.ParentFolderId != null)
            {
                Folder parentFolder = _context.Folders.FirstOrDefault(f => f.Id == item.ParentFolderId);
                newFolder.ParentFolder = parentFolder;
            }

            _context.SaveChanges();
            return _context.SaveChanges();
        }

        public bool Remove(int id)
        {
            Folder folder = _context.Folders.FirstOrDefault(f => f.Id == id);

            if (folder != null)
            {
                _context.Folders.Remove(folder);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(FolderDTO item)
        {
            Folder folder = _context.Folders.FirstOrDefault(f => f.Id == item.Id);

            if (folder != null)
            {
                folder.Name = item.Name;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public static FolderDTO EntityToDTO(Folder folder)
        {
            if (folder == null)
                return null;

            return new FolderDTO
            {
                Id = folder.Id,
                ParentFolderId = folder.ParentFolderId,
                Name = folder.Name,
                Folders = folder.Folders.Select(item => item.Name).ToList(),
                Files = folder.Files
                    .Where(item => item.FolderId == folder.Id)
                    .Select(item => FileManager.EntityToDTO(item))
                    .ToList()
            };
        }
    }
}
