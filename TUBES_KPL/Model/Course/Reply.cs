using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tubes_KPL.Model.Person;

namespace Tubes_KPL.Model.Course
{
    public class Reply
    {
        private int _replyId;
        private string _replyDescription;
        public string CreateBy { get; }
        public DateTime CreateAt { get; }
        public static int GlobalReplyID;

        public Reply(Lecturer lecturer, string replyDescription)
        {
            try
            {
                if ((lecturer == null) || (String.IsNullOrEmpty(replyDescription)))
                    throw new ArgumentNullException("Input should not be blank!");

                _replyId = Interlocked.Increment(ref GlobalReplyID);
                _replyDescription = replyDescription;
                CreateAt = DateTime.Now;
                CreateBy = lecturer.EmployeeName;
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e.ParamName);
            }
        }

        
        public Reply(Student student, string replyDescription)
        {
            try
            {
                if ((student == null) || (String.IsNullOrEmpty(replyDescription)))
                    throw new ArgumentNullException("Input should not be blank!");

                _replyId = Interlocked.Increment(ref GlobalReplyID);
                _replyDescription = replyDescription;
                CreateAt = DateTime.Now;
                CreateBy = student.StudentName;
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e.ParamName);
            }
        }

        public string ReplyDescription
        {
            get { return _replyDescription; }
            set
            {
                try
                {
                    if (String.IsNullOrEmpty(value))
                        throw new ArgumentNullException("Input should not be blank");

                    _replyDescription = value;
                }
                catch (ArgumentNullException e)
                {
                    Console.Error.WriteLine(e.ParamName);
                }
                
            }
        }



    }
}
