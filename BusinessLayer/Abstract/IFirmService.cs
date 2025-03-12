using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFirmService
    {
        List<Firm> GetList();
        void FirmAdd(Firm firm);
        void FirmDelete(Firm firm);
        void FirmUpdate(Firm firm);
        Firm GetByID(int id);
    }
}
