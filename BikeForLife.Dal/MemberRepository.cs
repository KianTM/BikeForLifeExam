using BikeForLife.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BikeForLife.Dal
{
    public class MemberRepository : BaseRepository
    {
        public List<Member> GetAll()
        {
            string sql = "SELECT * FROM Members";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
                throw new InvalidOperationException($"DataTable was null. SQL string is: {sql}");
            return HandleData(dataTable);
        }

        public Member GetWithId(int id)
        {
            string sql = $"SELECT * FROM Members WHERE MemberId={id}";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
                throw new InvalidOperationException($"DataTable was null. SQL string is: {sql}");
            List<Member> members = HandleData(dataTable);

            if (members.Count == 0)
            {
                return null;
            }

            return members[0];
        }

        private List<Member> HandleData(DataTable dataTable)
        {
            if (dataTable == null)
                return null;

            List<Member> members = new List<Member>();

            foreach (DataRow row in dataTable.Rows)
            {
                members.Add(new Member()
                {
                    Id = (int)row["MemberId"],
                    Name = (string)row["Name"],
                    EnrollmentDate = (DateTime)row["EnrollmentDate"]
                });
            }
            return members;
        }
    }
}
