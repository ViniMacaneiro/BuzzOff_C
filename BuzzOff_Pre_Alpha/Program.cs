// See https://aka.ms/new-console-template for more information
using BuzzOff_Pre_Alpha.Model;
using BuzzOff_Pre_Alpha.Repository;
using PrototipoDengue.View;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security;

Console.SetWindowSize((Console.LargestWindowWidth * 2 )/3, (Console.LargestWindowHeight*2)/3);
Console.ForegroundColor = ConsoleColor.Yellow;

Console.CursorLeft = Console.LargestWindowWidth/10;
Console.CursorTop = Console.LargestWindowHeight/40;


CreateDB create = new CreateDB();
StartView start = new StartView();
start.Start();




