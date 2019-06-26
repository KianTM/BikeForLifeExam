using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeForLife.Dal;
using BikeForLife.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeForLife.Web.Pages
{
    public class MembersModel : PageModel
    {
        public List<Member> Members { get; set; }
        public List<Ride> Rides { get; set; }

        public IActionResult OnGet()
        {
            return InitializeData();
        }

        public IActionResult InitializeData()
        {
            MemberRepository memberRepository = new MemberRepository();
            RideRepository rideRepository = new RideRepository();

            try
            {
                Members = memberRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            try
            {
                Rides = rideRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            foreach (Member member in Members)
            {
                foreach (Ride ride in Rides)
                {
                    if (ride.Member.Id == member.Id)
                    {
                        member.Add(ride);
                    }
                }
            }

            return Page();
        }
    }
}