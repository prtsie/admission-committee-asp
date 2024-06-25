using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdmissionCommitteeASP.Models;
using AdmissionCommitteeASP.Services;
using Database.Models;

namespace AdmissionCommitteeASP.Controllers;

public class ApplicantsController(DbAccessService db) : Controller
{
    public async Task<IActionResult> List()
    {
        var applicants = await db.GetApplicants();
        return View(applicants);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await db.DeleteApplicantAsync(id);
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid? id)
    {
        var applicant = id == null ? new Applicant() : await db.FindApplicantAsync(id.Value);
        return View(applicant);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Applicant applicant)
    {
        if (ModelState.IsValid)
        {
            if (await db.FindApplicantAsync(applicant.Id) != null)
            {
                await db.UpdateApplicantAsync(applicant);
            }
            else
            {
                await db.AddApplicant(applicant);
            }

            return RedirectToAction(nameof(List));
        }
        else
        {
            return BadRequest();
        }
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
