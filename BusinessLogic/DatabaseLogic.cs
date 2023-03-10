using System.ComponentModel.DataAnnotations;
using DataAccess;

namespace BusinessLogic
{
    public class GoodsDB
    {
        private MyDbContext db = new MyDbContext();
        public List<Good> Enable()
        {
            return db.Goods.Where(p => p.Amount > 0).Select(p => p).ToList();
        }
        public List<Good> Enable(string Title)
        {
            return db.Goods.Where(p => p.Title.ToLower().Contains(Title.ToLower())).Select(p => p).ToList();
        }
        public void Add(int Id,string Title,decimal Price,
            int StartAmount, string Desc = "")
        {
            try
            {
                Good NewGood = new Good();
                NewGood.Id = Id;
                NewGood.Title = Title;
                NewGood.Price = Price;
                NewGood.Amount = StartAmount;
                NewGood.Descryption = Desc;
                db.Goods.Add(NewGood);
                db.SaveChanges();
            }
            catch { }
        }

        public void Change(int Id, string Title = "", decimal Price = 0,
            int AmountChange = 0, string Desc = "")
        {
            try
            {
                Good? NewGood = db.Goods.Where(p => p.Id == Id).Select(p => p).FirstOrDefault();
                if (NewGood != null)
                    throw new Exception();
                NewGood.Title = Title == "" ? NewGood.Title : Title;
                NewGood.Price = Price == 0 ? NewGood.Price : Price;
                NewGood.Amount = AmountChange;
                NewGood.Descryption = Desc == "" ? NewGood.Descryption : Desc;
                db.Goods.Update(NewGood);
                db.SaveChanges();
            }
            catch { }
        }

        public void Delete(int Id)
        {
            try
            {
                Good? GoodForDelete = db.Goods.Where(p => p.Id == Id).Select(p => p).FirstOrDefault();
                if (GoodForDelete == null)
                    throw new Exception();
                db.Goods.Update(GoodForDelete);
                db.SaveChanges();
            }
            catch { }
        }
    }
    public class ShipDB
    {

    }
    public class UserDB
    {

    }
    public class ListDB
    {

    }
}