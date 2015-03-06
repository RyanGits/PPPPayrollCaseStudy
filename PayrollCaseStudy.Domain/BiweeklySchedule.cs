﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollCaseStudy.Domain {
    public class BiweeklySchedule : PaymentSchedule{
        readonly static Date ReferenceDate = new Date(3,6,2015); // a friday

        public bool IsPayDate(Date date) {
            if(date.DayOfWeek != DayOfWeek.Friday) {
                return false;
            }

            var weekSince = date.DaySince(ReferenceDate) / 7;
            if(weekSince%2==0) {
                return true;
            }
            return false;
        }
    }
}
