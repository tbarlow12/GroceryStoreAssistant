using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json.Converters;


namespace GroceryStoreAssistant.Dialogs
{
    [LuisModel("43ec4ca3-c25e-4ea9-9653-ab6c2f7efd80", "3a4a822af4ac4d72b33402bd40fb19d5")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }



        [LuisIntent("OrderItem")]
        public async Task OrderItem(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(Newtonsoft.Json.JsonConvert.SerializeObject(result));
            context.Wait(this.MessageReceived);
        }

        
    }
}