﻿using Nancy;
using Nancy.Hosting.Self;
using System;
using System.Diagnostics;
using CozyNote.ServerCore.Database;

namespace CozyNote.ServerCore
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = x =>
            {
                return "hello world!";
            };
        }
    }

    public class ServerHost
    {
        public static void Run(string uri)
        {
            HostConfiguration hostConfigs = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };
            var host = new NancyHost(new Uri(uri), new DefaultNancyBootstrapper(), hostConfigs);
            host.Start();
            TestData();
        }

        public static void TestData()
        {

            var notebook = new Model.ObjectModel.Notebook()
            {
                name = "testbook",
                pass = "654321"
            };
            var notebookid = DbHolding.Notebook.Create(notebook);

            var user = new Model.ObjectModel.User()
            {
                nickname    = "kingwl",
                pass        = "123456"
            };

            user.notebook_list.Add(notebookid);

            var userid = DbHolding.User.Create(user);

            var note = new Model.ObjectModel.Note()
            {
                name        = "testnote",
                type        = 1,
                notebook_id = notebookid,
                data        = "testdata"
            };
            var noteid = DbHolding.Note.Create(note);

            notebook.note_list.Add(noteid);
            notebook.notes_num++;

            
            DbHolding.User.Update(user);
            DbHolding.Notebook.Update(notebook);
        }
    }
}