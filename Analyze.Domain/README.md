## Architecture
https://www.c-sharpcorner.com/article/clean-architecture-in-asp-net-core-web-api/
### Todo's

#### Yahoo or not?
* Use Yahoo finance or not? Scrape problem....
  * Build model that has all data required for Kpi's
  * Minimize number of request made (1 would be optimal)
  * Generate all Kpi's from data model

#### Verify which Kpi's to use 
* Email Erik

#### Fetch Makros from riksbankens api
  * inflation
  * swe krona
  * BNP
  * interest rate

#### Determination
* Build Determination Factory that returns a simple recomendation based on KPI's
  * Vilka regler skall man utgå från för att ge en rekomendation?
* Build endpoint that returns all KPI's used in the recomendation (for user if they want to know)
* Build endpoint that considers Makro variables

### When above is done refactor - Put some time into this


## Future features
* Build frontend 
  * JwtBearer token
* Save determinations for stocks?
* Provide user with email if makros changes
* Build Auth Service
  * build register / login service
  * build subscription and payment to charge user service
  * Extract Yahoo or whatever to its own service
* CI/CD
* Kubernetes 