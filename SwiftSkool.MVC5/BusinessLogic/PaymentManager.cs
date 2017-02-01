//using SchoolPortal.ViewModels;
//using SwiftSkools.Entities;
//using System.Threading.Tasks;
//using SwiftSkools.Abstractions;

//namespace SwiftSkool.MVC5.BusinessLogic
//{
//    public class PaymentManager : IPaymentManager
//    {
//        private readonly IQueryRepository qdb;
//        private readonly ICommandRepository<PaymentType> _dbquery;

//        public PaymentManager(IQueryRepository db,
//            ICommandRepository<PaymentType> dbquery)
//        {
//            qdb = db;
//            _dbquery = dbquery;
//        }

//        ///<summary>
//        ///method to create a new payment
//        ///</summary>
//        ///<returns></returns>
//        public async Task<int> CreatePayment(PaymentInputModel payment)
//        {
//            var newPayment = new PaymentType();
//            //make sure that all the requirements are met before a payment
//            //can be made

//            return await _dbquery.SaveAsync();

//        }
//        //public async Task UpdatePayment(PaymentInputModel UpdatePayment)
//        //{

//        //}

//        /////<summary> 
//        /////method to show all payment status for all student
//        /////</summary>
//        /////<param name ="paymentID"></param>
//        /////<returns> List of all Student that has Payed </returns>
//        //public List<PaymentStatusViewModel> StudentPaymentStatus(int paymentID)
//        //{
//        //    var status = _db.GetPaymentStatusForStudent(paymentID);
//        //    return status;
//        //}
//        /////<summary> 
//        /////method to show payment status for all student
//        /////</summary>
//        /////<param name ="status"></param>
//        /////<returns> List of all Student that has Payed </returns>        
//        //public List<PaymentStatusesViewModel> AllStudentPaymentStatus(string paymentstatus)
//        //{
//        //    var status = _db.GetStudentsWithPaymentStatus(paymentstatus);
//        //    return status;
//        //}
//        //public List<PaymentStatusViewModel> StudentWithFullPayment(string paid)
//        //{
//        //    var fullyPaid = _db.GetStudentsWithFullPayment(paid);
//        //    return fullyPaid;
//        //}
//        /////<summary> 
//        /////Search for student by payment date
//        /////</summary>
//        /////<param name ="paymentDate"></param>
//        /////<returns> List PaymentViewModel </returns>  
//        //public List<PaymentViewModel> PaymentByDate(DateTime beginDate, DateTime endDate)
//        //{
//        //    var paymentDate = _db.GetPaymentByDate(beginDate, endDate);
//        //    return paymentDate;
//        //}


//        //private Payment SetPayment(PaymentInputModel payinput, SchoolSession session)
//        //{
//        //    var payment = new Payment();
//        //    var schoolsession = new SchoolSession();
//        //    if(payinput != null) //makes sure that the input is valid
//        //    {
//        //        //make sure the fees are paid before term ends
//        //        if (payinput.PaymentDate <= session.TermEnds)
//        //            payinput.PaymentDate = payment.PaymentDate;
//        //        //makes sure that a currently attending student is paying any fees
//        //        if (payinput.Student.Active != false)
//        //            payinput.Student = payment.Student;
//        //        if (payinput.Session == session.SessionName && payinput.Term == session.Term.ToString())
//        //            payinput.Session = schoolsession.SessionName;

//        //    }
//        //    return payment;
//        //}

//    }
//}