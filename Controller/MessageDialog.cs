using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umoxi
{
    class MessageDialog
    {
        public static string TextMessage(string Message)
        {
            #region Message

            switch (Message)
            {
                case "Saved":
                    //////////////////Saved//////////////
                    Message = "A informação foi salva com sucesso!";
                    break;
                case "Update":
                    //////////////////Update//////////////
                    Message = "A informação foi atualizada com sucesso!";
                    break;
                case "Delete":
                    //////////////////Delete//////////////
                    Message = "A informação foi excluída com sucesso!";
                    break;
                case "Email":
                    //////////////////Email//////////////
                    Message = "A informação foi enviada com sucesso!";
                    break;

            }

            #endregion

            return Message;
        }
    }
}
