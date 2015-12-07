using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam_MVCTask1_ByAleksieiev_BLL
{
    public interface IGameService
    {
        List<GameDTO> GetAllGames();
        void DeleteGame(GameDTO game);
        void CreateGame(GameDTO game);
        void ModifyGame(GameDTO game);
        GameDTO GetGameById(int id);

    }
}
