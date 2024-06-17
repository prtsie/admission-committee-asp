using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdmissionCommitteeASP.Models;
using AdmissionCommitteeASP.Services;

namespace AdmissionCommitteeASP.Controllers;

public class ApplicantsController(DbAccessService db) : Controller
{

    public async Task<IActionResult> List()
    {
        var applicants = await db.GetApplicants();
        return View(applicants);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
