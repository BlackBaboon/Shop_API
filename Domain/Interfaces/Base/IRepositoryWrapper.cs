using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGoodsRepository Good { get; }
        IUserRepository User { get; }
        IGoodsListRepository GoodsList { get; }
        ICommentRepository Comment { get; }
        ILikedListRepository LikedList { get; }
        IShipsRepository Ship { get; }

        Task Save();
    }
}
