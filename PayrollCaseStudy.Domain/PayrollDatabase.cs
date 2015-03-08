﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollCaseStudy.Domain {
    public class PayrollDatabase {
        readonly Dictionary<int, Employee> _itsEmployees = new Dictionary<int,Employee>();
        readonly Dictionary<int,int> _unionMemberMap = new Dictionary<int,int>();

        public Employee GetEmployee(int employeeId) {
            if(_itsEmployees.ContainsKey(employeeId)) {
                return _itsEmployees[employeeId];
            }
            
            return null;
        }
        public void AddEmployee(int employeeId, Employee employee) {
            _itsEmployees[employeeId] = employee;
        }
        public void Clear() {
            _itsEmployees.Clear();
        }

        PayrollDatabase(){}

        public readonly static PayrollDatabase Instance = new PayrollDatabase();

        internal void DeleteEmployee(int employeeId) {
            _itsEmployees.Remove(employeeId);
        }

        public void AddUnionMember(int memberId,Employee employee) {
            _unionMemberMap[memberId] = employee.EmployeeId;
        }

        public Employee GetUnionMember(int memberId) {
            if(!_unionMemberMap.ContainsKey(memberId)) {
                return null;
            }
            return GetEmployee(_unionMemberMap[memberId]);
        }

        internal ICollection<int> GetAllEmployeeIds() {
            return _itsEmployees.Keys;
        }


        internal void RemoveUnionMember(int memberId) {
            _unionMemberMap.Remove(memberId);
        }
    }
}
