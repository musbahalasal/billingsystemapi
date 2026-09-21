using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingsystem2;

[Route("api/[controller]")]
[ApiController]
public class InvoiceItemsController : ControllerBase
{
    private readonly AppDbContext _context;
    public InvoiceItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/InvoiceItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceItem>>> GetInvoiceItem()
    {
        return await _context.InvoiceItems.ToListAsync();
    }

    // GET: api/InvoiceItem/5
    [HttpGet("{invoiceitemid}")]
    public async Task<ActionResult<InvoiceItem>> GetInvoiceItem(int invoiceitemid)
    {
        var invoiceitem = await _context.InvoiceItems.FindAsync(invoiceitemid);

        if (invoiceitem == null)
        {
            return NotFound();
        }

        return invoiceitem;
    }

    // PUT: api/InvoiceItem/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{invoiceitemid}")]
    public async Task<IActionResult> PutInvoiceItem(int? invoiceitemid, InvoiceItem invoiceitem)
    {
        if (invoiceitemid != invoiceitem.InvoiceItemId)
        {
            return BadRequest();
        }

        _context.Entry(invoiceitem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceItemExists(invoiceitemid))
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

    // POST: api/InvoiceItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<InvoiceItem>> PostInvoiceItem(InvoiceItem invoiceitem)
    {
        _context.InvoiceItems.Add(invoiceitem);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInvoiceItem", new { invoiceitemid = invoiceitem.InvoiceItemId }, invoiceitem);
    }

    // DELETE: api/InvoiceItem/5
    [HttpDelete("{invoiceitemid}")]
    public async Task<IActionResult> DeleteInvoiceItem(int? invoiceitemid)
    {
        var invoiceitem = await _context.InvoiceItems.FindAsync(invoiceitemid);
        if (invoiceitem == null)
        {
            return NotFound();
        }

        _context.InvoiceItems.Remove(invoiceitem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InvoiceItemExists(int? invoiceitemid)
    {
        return _context.InvoiceItems.Any(e => e.InvoiceItemId == invoiceitemid);
    }
}
