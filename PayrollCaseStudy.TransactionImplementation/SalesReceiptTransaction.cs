﻿using PayrollCaseStudy.CommonTypes;
using PayrollCaseStudy.PayrollDatabase;
using PayrollCaseStudy.PayrollDomain;
using PayrollCaseStudy.TransactionApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCaseStudy.TransactionImplementation {
    public class SalesReceiptTransaction : Transaction{
        private decimal _amount;
        private Date _forDate;
        private int _employeeId;
        
        public SalesReceiptTransaction(decimal amount,Date forDate, int employeeId) {
            _forDate = forDate;    
            _amount = amount;
            _employeeId = employeeId;
        }
        public void Execute() {
            var employee =  PayrollDatabase.Scope.DatabaseInstance.GetEmployee(_employeeId);

            if(employee == null) {
                throw new Exception("Employee not found");
            }

            

            var classification = employee.GetClassification();
            
            classification.AddSalesReceipt(_amount,_forDate);
            
            
        }
    }
}
