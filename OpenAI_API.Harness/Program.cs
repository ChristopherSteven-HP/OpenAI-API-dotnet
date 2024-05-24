// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using OpenAI_API.Chat;
using System;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
string tenantId = Environment.GetEnvironmentVariable("SECRET_TENANT_ID") ?? "";
string clientId = Environment.GetEnvironmentVariable("SECRET_CLIENT_ID") ?? "";
string clientSecret = Environment.GetEnvironmentVariable("SECRET_KEY") ?? "";
string SECRET_VALUE = Environment.GetEnvironmentVariable("SECRET_VALUE") ?? "";
string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME") ?? "";
string keyName = Environment.GetEnvironmentVariable("KEY_VAULT_KEY_NAME") ?? "";
string openAIResourceName = Environment.GetEnvironmentVariable("OPENAI_RESOURCE_NAME") ?? "";
string openAIDeploymentName = Environment.GetEnvironmentVariable("OPENAI_DEPLOYMENT_NAME") ?? "";

//var clientCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
//var auth = new OpenAI_API.APIAuthentication(keyVaultName, keyName, clientCredentials);
var auth = new OpenAI_API.APIAuthentication(SECRET_VALUE);
var _OpenAPI = OpenAI_API.OpenAIAPI.ForAzure(openAIResourceName, openAIDeploymentName, auth);


//Test Models
var models = await _OpenAPI.Models.GetModelsAsync();
var modelNames = models.Select(t => t.ModelID);


//Test Assistants
var assistants = await _OpenAPI.Assistants.GetAssistantsAsync();

var assistantRequest = new OpenAI_API.Assistants.AssistantRequest();
assistantRequest.Model = "";
assistantRequest.Name = "Test";


var assistant = await _OpenAPI.Assistants.CreateAssistantAsync(assistantRequest);

assistants = await _OpenAPI.Assistants.GetAssistantsAsync();

foreach (var a in assistants)
{
    if(a.Name.StartsWith("Test"))
        await _OpenAPI.Assistants.DeleteAssistantAsync(a.Id);
}

//Test Files
var files = await _OpenAPI.Files.GetFilesAsync();
await _OpenAPI.Files.UploadFileAsync("training.jsonl", "fine-tune");
files = await _OpenAPI.Files.GetFilesAsync();
var chat = _OpenAPI.Chat.CreateConversation();

chat.Model = OpenAI_API.Models.Model.GPT4;

for(var i = 0; i < 5;  i++)
{
    chat.AppendUserInput("Test");
}

var tokens = chat.TokenCount();

var response = await chat.GetResponseFromChatbotAsync();
Console.WriteLine(response);
Debugger.Break();