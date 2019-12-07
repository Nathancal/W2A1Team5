using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using VapeShop.App_Code.DAL;

namespace VapeShop.App_Code.BLL
{
    public class Conversation
    {

        public Conversation() { 
        
        }

        public static DataSet getConversation() {
            return DataAccess.getMessages();
        
        }
    }
}