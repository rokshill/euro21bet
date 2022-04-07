import {
	HttpEvent,
	HttpHandler,
	HttpInterceptor,
	HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AuthService } from "@auth0/auth0-angular";
import { Observable } from "rxjs";
import { catchError, mergeMap } from "rxjs/operators";

@Injectable({
	providedIn: "root",
})
export class MyAuthHttpInterceptor implements HttpInterceptor {
	constructor(private auth: AuthService) {}

	public intercept(
		req: HttpRequest<unknown>,
		next: HttpHandler
	): Observable<HttpEvent<unknown>> {
		const isCallToApi = req.url.includes("api/");

		if (isCallToApi) {
			console.log("Trying add authorization header to request...");
			return this.auth.getAccessTokenSilently().pipe(
				mergeMap((token) => {
					const tokenReq = req.clone({
						setHeaders: { Authorization: `Bearer ${token}` },
					});

					return next.handle(tokenReq);
				}),
				// catchError((err: unknown) => throwError(err))
				catchError((err: unknown) => {
					console.log(err);
					return next.handle(req);
				})
			);
		}
		return next.handle(req);
	}
}
