using Microsoft.AspNetCore.Mvc;
using Server.Models;



[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
   
    private static readonly List<Loan> loans = new List<Loan>
    {
        new Loan { LoanType = "Personal Loans", Id = 1 },
        new Loan { LoanType = "Unsecured Loans", Id = 2 },
        new Loan { LoanType = "Student Loans", Id = 3 }
    };


    [HttpGet]
    public ActionResult<IEnumerable<Loan>> GetLoan()
    {
        return Ok(loans);
    }

    
    [HttpPost]
    public ActionResult AddLoan([FromBody] Loan newLoan)
    {
         newLoan.Id = loans.Count + 1;
            loans.Add(newLoan);
            return CreatedAtAction(nameof(GetLoan), new { id = newLoan.Id }, newLoan);
    }



    [HttpPut("{id}")]
    public ActionResult UpdateLoan(int id, [FromBody] Loan updatedLoan)
    {
         var loan = loans.Find(l => l.Id == id);
         if (loan == null) return NotFound();

    
        loan.LoanType = updatedLoan.LoanType;
            
        return Ok(loan);
    }



    
    [HttpDelete("{id}")]
    public ActionResult DeleteLoan(int id)
    {
             var loan = loans.Find(l => l.Id == id);
            if (loan == null) return NotFound();

            loans.Remove(loan);
            return NoContent();
    }
}