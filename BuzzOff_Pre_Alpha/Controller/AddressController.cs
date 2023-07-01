using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuzzOff_Pre_Alpha.Controller
{
    internal class AddressController
    {
        private AddressDAO addressDAO;

        public AddressController()
        {
            addressDAO = new AddressDAO();
        }

        public int Insert(AddressModel model)
        {
            return addressDAO.Insert(model);
        }

        public void Update (AddressModel model)
        {
            addressDAO.Update(model);
        }

        public AddressModel GetOne(int id)
        {
            return addressDAO.GetOne(id);
        }

        public List<AddressModel> GetAll()
        {
            return addressDAO.GetAll();
        }

        public void Delete(int id)
        {
            addressDAO.Delete(id);
        }
    }
}
