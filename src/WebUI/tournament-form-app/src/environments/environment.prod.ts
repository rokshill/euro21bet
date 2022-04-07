export const environment = {
	production: true,
	auth: {
		domain: "muchoborwroclaw.eu.auth0.com",
		clientId: "EBXOeLPbOEyfE1cV7m07Lk8o5NqZffm0",
		audience: "https://tournament-form.muchoborwroclaw.pl/api",
		scope: "access_as_admin email",
	},
	api: {
		endpoint: "https://localhost:5001/api/",
	},
};
