using System;
using System.Collections.Generic;
using System.Text;

namespace MeditocTest.Model
{
    public class Status
    {
        public int Code { get; set; }
        public string Description { get; set; }
        Status(int code, string description)
        {
            Code = code;
            Description = description;
        }

        static public Status OK()
        {
            return new Status(0, "OK");
        }
        static public Status Error(string message)
        {
            return new Status(500, message);
        }
    }
    public class RequesStatus
    {
        public Status State{ get; set; }
        public dynamic Response { get; set; }

        RequesStatus(Status st, object obj)
        {
            State = st;
            Response = obj;
        }
        static public RequesStatus OK(object obj=null)
        {
                return new RequesStatus(Status.OK(), obj);
        }
        static public RequesStatus Error(string message, dynamic obj = null)
        {
            return new RequesStatus(Status.Error(message), obj);
        }
    }
}
