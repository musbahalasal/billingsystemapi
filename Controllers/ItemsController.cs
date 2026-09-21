using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using billingsystem2;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ItemsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Item
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItem()
    {
        return await _context.Items.ToListAsync();
    }

    // GET: api/Item/5
    [HttpGet("{itemid}")]
    public async Task<ActionResult<Item>> GetItem(int itemid)
    {
        var item = await _context.Items.FindAsync(itemid);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    // PUT: api/Item/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{itemid}")]
    public async Task<IActionResult> PutItem(int? itemid, Item item)
    {
        if (itemid != item.ItemId)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(itemid))
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

    // POST: api/Item
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { itemid = item.ItemId }, item);
    }

    // DELETE: api/Item/5
    [HttpDelete("{itemid}")]
    public async Task<IActionResult> DeleteItem(int? itemid)
    {
        var item = await _context.Items.FindAsync(itemid);
        if (item == null)
        {
            return NotFound();
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ItemExists(int? itemid)
    {
        return _context.Items.Any(e => e.ItemId == itemid);
    }
}
