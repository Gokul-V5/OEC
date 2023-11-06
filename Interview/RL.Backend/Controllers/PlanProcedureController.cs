using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RL.Data;
using RL.Data.DataModels;
using System.Numerics;

namespace RL.Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class PlanProcedureController : ControllerBase
{
    private readonly ILogger<PlanProcedureController> _logger;
    private readonly RLContext _context;

    public PlanProcedureController(ILogger<PlanProcedureController> logger, RLContext context)
    {
        _logger = logger;
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    [EnableQuery]
    public IEnumerable<PlanProcedure> Get()
    {
        var DataResult = _context.PlanProcedures.Select(pp => new PlanProcedure
        {
            ProcedureId = pp.ProcedureId,
            PlanId = pp.PlanId ,
            UserId = pp.UserId == 0 ? null : pp.UserId,
            Procedure =pp.Procedure,
            Plan = pp.Plan,
            CreateDate = pp.CreateDate,
            UpdateDate = pp.UpdateDate
        })
    .ToList(); 
        return DataResult;
    }
}
