using AutoMapper;
using JasminTravel.BLL.Interfaces;
using JasminTravel.DAL.Context;
using JasminTravel.DAL.Models;
using JasminTravel.PL.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Stripe.Checkout;
using Stripe;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace JasminTravel.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JasminTravelsPRGcontext _context;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IpkgRepo _pkgRepo;
        private readonly IcontactRepo _contactRepo;
        private readonly IMapper _mapper;
        private readonly IcommentRepo _commentRepo;
        private readonly stripe _stripe;
        private readonly IresRepo _resRepository;
        private readonly IOptions<stripe> _options;
        public string SessionId { get; set; } 

        public HomeController(ILogger<HomeController> logger 
                            , JasminTravelsPRGcontext context
                            , IStringLocalizer<HomeController> localizer
                            , IpkgRepo pkgRepo
                            , IcontactRepo contactRepo
                            , IMapper mapper
                            , IcommentRepo commentRepo
                            , IOptions<stripe> stripe
                            , IresRepo resRepo)
        {
            _logger = logger;
            _pkgRepo = pkgRepo;
            _contactRepo = contactRepo;
            _context = context;
            _localizer = localizer;
            _mapper = mapper;
            _commentRepo = commentRepo;
            _stripe = stripe.Value;
            _resRepository = resRepo;
        }


        public async Task<IActionResult> Index()
        {
            var Pkg = await _pkgRepo.GetAllAscync();

            var mappedPkg = _mapper.Map<IEnumerable<Pkg>, IEnumerable<PkgViewModel>>(Pkg);

            IEnumerable<PkgViewModel> orderPkg = mappedPkg.OrderByDescending(x => x.Id).ToList();

            return View(orderPkg);
        }

        [Route("About")]
        public async Task<IActionResult> AboutUs()
        {
            return View();
        }
        
        [Route("Terms")]
        public async Task<IActionResult> Terms()
        {
            return View();
        }
        
        [Route("Policy")]
        public async Task<IActionResult> Policy()
        {
            return View();
        }
        
        [Route("Refund-Policy")]
        public async Task<IActionResult> PaymentAndRefund()
        {
            return View();
        }

        [Route("Contact")]
        public async Task<IActionResult> Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public async Task<IActionResult> Contact(ContactViewModel contactVM)
        {
            if (ModelState.IsValid)
            {
                var mappedContact = _mapper.Map<ContactViewModel, Contact>(contactVM);

                int count = await _contactRepo.Add(mappedContact);

                if (count > 0)
                    TempData["MessageFromContact"] = "Thanks For Contact With Us:)";

                return RedirectToAction(nameof(Contact));
            }
            return View();
        }

        [Route("Pkg")]
        public async Task<IActionResult> Pkg()
        {
            var Pkg = await _pkgRepo.GetAllAscync();

            var mappedPkg = _mapper.Map<IEnumerable<Pkg>, IEnumerable<PkgViewModel>>(Pkg);

            IEnumerable<PkgViewModel> orderPkg = mappedPkg.OrderByDescending(p => p.Id).ToList();

            return View(orderPkg);
        }

        [HttpGet]
        public async Task<IActionResult> PkgDetails([FromRoute] int? id)
        {
            if (id is null)
                return NotFound();

            var package = await _pkgRepo.Get(id.Value);

            if (package == null)
                return NotFound();
            var mappedPkg = _mapper.Map<Pkg, PkgViewModel>(package);

            var FakePrice = (mappedPkg.PriceStart * 120 / 100);

            ViewData["FakePrice2"] = FakePrice;

            return View(mappedPkg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PackageDetails(PkgViewModel model)
        {
                var count = await _commentRepo.Add(model.comment);
            if (count > 0)
                TempData["CommentMessage"] = "Comment added successfully!";
             
            var package = await _pkgRepo.Get(model.Id);

            if (package == null)
                return NotFound();

            var mappedPkg = _mapper.Map<Pkg, PkgViewModel>(package);

            return RedirectToAction(nameof(PackageDetails),mappedPkg.Id);
        }
       
        [HttpGet]
        public async Task<IActionResult> res([FromRoute] int? id)
        {
            if (id is null)
                return NotFound();

            var package = await _pkgRepo.Get(id.Value);

            if (package == null)
                return NotFound();

            var mappedPkg = _mapper.Map<Pkg, PkgViewModel>(package);

            var FakePrice = (mappedPkg.PriceStart * 120/100);

            ViewData["FakePrice"] = FakePrice;

            return View(mappedPkg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> res([FromRoute] int? id , PkgViewModel PKGVM)
        {
            StripeConfiguration.ApiKey = _stripe.Secretkey;

            var res = _mapper.Map<ResViewModel, Res>(PKGVM.res);
            var count = await _resRepository.Add(res);

            if (count > 0)
                TempData["resMessage"] = "Certainly, you will receive communication within the next 24 hours!";

            var package = await _pkgRepo.Get(PKGVM.Id);

            var amount = CalculateresAmount(package, res);

            var session = await CreateStripeSession(amount , package);

            // Redirect user to Stripe checkout page
            return Redirect(session.Url);
        }

        #region Sessionres
        private int CalculateresAmount(Pkg package, Res res)
        {
            #region Switch
            int amount = 0;

            Console.WriteLine($"HotelType: {res.RevHotelType}");


            switch (res.RevHotelType)
            {
                case "Four Star":

                    Console.WriteLine("Calculating amount for FourStar hotel");

                    amount = (
                        (
                            hidden Calculated
                        ) * 100
                    );
                    break;
                case "Five Star":

                    Console.WriteLine("Calculating amount for FiveStar hotel");

                    amount = (
                        (
                           hidden Calculated
                        ) * 100
                    );
                    break;
            }
            #endregion
            Console.WriteLine($"Calculated amount: {amount}");

            return amount;
        }

        private async Task<Session> CreateStripeSession(int amount , Pkg package)
        {
            var currency =  hidden content; // Currency code
            var successUrl =  hidden content
            var cancelUrl =  hidden content

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            hidden content
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };

            var service = new SessionService();
            var session = service.Create(options);
            SessionId = session.Id;

            return session;
        }
        #endregion

        

        public IActionResult DownloadPdf(string folderName, string fileName)
        {
            var result = Helpers.DecumentSettings.DownloadFile(folderName, fileName);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> RatePkg(int PId, int rating )
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Check if the user has already rated this package
            bool hasRated = _context.Ratings
                .Any(r => r.Id == PId && r.UserIPAddress == ipAddress);

            if (hasRated)
            {
                TempData["MessageRating"] = "You have already rated this package :)";
            }

            // Add new rating
            var newRating = new PRating
            {
                Id = PId,
                PKGRatingStars = rating,
                UserIPAddress = ipAddress,
            };

            await _context.Ratings.AddAsync(newRating);
            await _context.SaveChangesAsync();

            // Recalculate average rating for the package
            var package = _context.Pkg.Find(PId);
            if (package != null)
            {
                package.PKGRatingCount++;
                package.PKGRating = (float?)((_context.Ratings
                    .Where(r => r.Id == PId)
                    .Sum(r => r.PKGRatingStars) + rating) / (double?)package.PKGRatingCount);

                _context.SaveChanges();
            }

            return RedirectToAction("PackageDetails", new { id = PId });
        }


        [HttpPost]
        public async Task<IActionResult> SetLanguage(string culture, string ReturnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(ReturnUrl);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}