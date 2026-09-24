using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingsystem2;
using billingsystem2;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly AppDbContext _context;
    public InvoicesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Invoice
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoice()
    {
        return await _context.Invoices.ToListAsync();
    }

    // GET: api/Invoice/5
    [HttpGet("{invoiceid}")]
    public async Task<ActionResult<Invoice>> GetInvoice(int invoiceid)
    {
        var invoice = await _context.Invoices.FindAsync(invoiceid);

        if (invoice == null)
        {
            return NotFound();
        }

        return invoice;
    }

    // PUT: api/Invoice/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{invoiceid}")]
    public async Task<IActionResult> PutInvoice(int? invoiceid, Invoice invoice)
    {
        if (invoiceid != invoice.InvoiceId)
        {
            return BadRequest();
        }

        _context.Entry(invoice).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceExists(invoiceid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Invoice
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInvoice", new { invoiceid = invoice.InvoiceId }, invoice);
    }

    // DELETE: api/Invoice/5
    [HttpDelete("{invoiceid}")]
    public async Task<IActionResult> DeleteInvoice(int? invoiceid)
    {
        var invoice = await _context.Invoices.FindAsync(invoiceid);
        if (invoice == null)
        {
            return NotFound();
        }

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InvoiceExists(int? invoiceid)
    {
        return _context.Invoices.Any(e => e.InvoiceId == invoiceid);
    }
}
