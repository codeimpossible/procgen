## STARS
| Class	| Effective temperature	| Vega-relative chromaticity	| Chromaticity (D65)	    | Main-sequence mass(solar masses)	| Main-sequence radius(solar radii)	| Main-sequence luminosity (bolometric)	| Hydrogen lines	| Fraction of all main-sequence stars |
|-------|-----------------------|-------------------------------|---------------------------|-----------------------------------|-----------------------------------|---------------------------------------|-------------------|-------------------------------------|
| O	    | ≥ 30,000 K	          | blue	                      | blue	                  | ≥ 16 M☉	                          | ≥ 6.6 R☉	                        | ≥ 30,000 L☉	                          | Weak	          | 0.000030%                           |
| B	    | 10,000–30,000 K	      | bluish white	              | deep bluish white	      | 2.1–16 M☉	                        | 1.8–6.6 R☉	                      | 25–30,000 L☉	                        | Medium	        | 0.12%                               |
| A	    | 7,500–10,000 K	      | white	                      | bluish white	          | 1.4–2.1 M☉	                      | 1.4–1.8 R☉	                      | 5–25 L☉	                              | Strong	        | 0.61%                               |
| F	    | 6,000–7,500 K	        | yellowish white	            | white	                  | 1.04–1.4 M☉	                      | 1.15–1.4 R☉	                      | 1.5–5 L☉	                            | Medium	        | 3.0%                                |
| G	    | 5,200–6,000 K	        | yellow	                    | yellowish white	        | 0.8–1.04 M☉	                      | 0.96–1.15 R☉	                    | 0.6–1.5 L☉	                          | Weak	          | 7.6%                                |
| K	    | 3,700–5,200 K	        | light orange	              | pale yellowish orange	  | 0.45–0.8 M☉	                      | 0.7–0.96 R☉	                      | 0.08–0.6 L☉	                          | Very weak	      | 12%                                 |
| M	    | 2,400–3,700 K	        | orangish red	              | light orangish red	    | 0.08–0.45 M☉	                    | ≤ 0.7 R☉	                        | ≤ 0.08 L☉	                            | Very weak	      | 76%                                 |

## Star Radii
R = radius of our Sun: 700,000Km
`0.08R - 60R`

## PLANETS
|   Planet  	| Orbital velocity        | Distance   | Albedo|
|---------------|-------------------------|------------|-------|
|   Mercury 	| 47.9 km/s (29.8 mi/s)   |  0.39AU    |  0.12 |
|   Venus   	| 35.0 km/s (21.7 mi/s)   |  0.72AU    |  0.75 |
|   Earth   	| 29.8 km/s (18.5 mi/s)   |  1.00AU    |  0.31 |
|   Mars    	| 24.1 km/s (15.0 mi/s)   |  1.52AU    |  0.25 |
|   Jupiter 	| 13.1 km/s (8.1 mi/s)    |  5.20AU    |  0.34 |
|   Saturn  	| 9.7 km/s (6.0 mi/s)     |  9.54AU    |  0.34 |
|   Uranus  	| 6.8 km/s (4.2 mi/s)     | 19.22AU    |  0.30 |
|   Neptune 	| 5.4 km/s (3.4 mi/s)     | 30.06AU    |  0.29 |

```javascript
var AU = 150 * 1e6; // distance to sun = 1 astornomical unit
function calcPlanetTemp(starTemp, starRadiusKM, distanceAU, absorbtion) {
  absorbtion = absorbtion || 0.7;
  return starTemp * Math.sqrt(starRadiusKM / (2 * distanceAU)) * Math.pow(absorbtion, 1 / 4);
}

function calcDistance(planetTemp, starTemp, starRadiusKM, absorbtion) {
  absorbtion = absorbtion || 0.7;
  return 1 / (Math.pow(planetTemp / starTemp / Math.pow(absorbtion, 1 / 4), 2) * 2 / starRadiusKM);
}

var planetTemp = calcPlanetTemp(6000, 700000, AU);
```
