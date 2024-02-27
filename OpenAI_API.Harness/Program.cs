// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using System;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
string tenantId = Environment.GetEnvironmentVariable("SECRET_TENANT_ID") ?? "";
string clientId = Environment.GetEnvironmentVariable("SECRET_CLIENT_ID") ?? "";
string clientSecret = Environment.GetEnvironmentVariable("SECRET_KEY") ?? "";
string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME") ?? "";
string keyName = Environment.GetEnvironmentVariable("KEY_VAULT_KEY_NAME") ?? "";
string openAIResourceName = Environment.GetEnvironmentVariable("OPENAI_RESOURCE_NAME") ?? "";
string openAIDeploymentName = Environment.GetEnvironmentVariable("OPENAI_DEPLOYMENT_NAME") ?? "";

var clientCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
var auth = new OpenAI_API.APIAuthentication(keyVaultName, keyName, clientCredentials);

var _OpenAPI = OpenAI_API.OpenAIAPI.ForAzure(openAIResourceName, openAIDeploymentName, auth);
var chat = _OpenAPI.Chat.CreateConversation();
chat.AppendUserInput("Test");
var response = await chat.GetResponseFromChatbotAsync();
Console.WriteLine(response);
Debugger.Break();