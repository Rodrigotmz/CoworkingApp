using CoworkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingApp.Data
{
    public class DeskData
    {
        private JsonManager<Desk> jsonManager;
        public DeskData()
        {
            jsonManager = new JsonManager<Desk>();
        }
        public (string,bool) CreateDesk(Desk desk)
        {
            var deskCollection = jsonManager.GetCollection();
            deskCollection.Add(desk);
            jsonManager.SaveCollection(deskCollection);
            return ("Se creo el escritorio con exito",true);
        }
        public Desk FindDesk(string numberDesk)
        {
            var userCollection = jsonManager.GetCollection();
            return userCollection.FirstOrDefault(p => p.Number == numberDesk);
        }
        public (string, bool) EditDesk(Desk desk)
        {
            var deskCollection = jsonManager.GetCollection();
            var indexDesk = deskCollection.FindIndex(p => p.DeskId == desk.DeskId);
            deskCollection[indexDesk] = desk;
            jsonManager.SaveCollection(deskCollection);
            return ("El Desk a sido actualizado con exito",true);
        }
        public (string, bool) DeleteDesk (Guid deskId)
        {
            try
            {
                var deskCollection = jsonManager.GetCollection();
                var idDesk = deskCollection.FindIndex(p => p.DeskId == deskId);
                deskCollection.RemoveAt(idDesk);
                jsonManager.SaveCollection(deskCollection);
                return ("Usuario removido con exito", true);
            }
            catch
            {
                return ("El usuario no se pudo remover", false);
            }
        }
    }
}
