import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { concatMap, pluck, tap } from 'rxjs/operators';

@Component({
	selector: 'e21b-metadata',
	template: `metadata<div>
    <pre>{{ metadata | json }}</pre>
  </div>`,
	styles: [],
})
export class UserMetadataComponent implements OnInit {
	public metadata = {};

	// Inject both AuthService and HttpClient
	constructor(public auth: AuthService, private http: HttpClient) { }

	public ngOnInit(): void {
		this.auth.user$
			.pipe(
				concatMap((user: any) =>
					// Use HttpClient to make the call
					this.http.get(encodeURI(`https://muchoborwroclaw.eu.auth0.com/api/v2/users/${user.sub}`))
				),
				pluck('user_metadata'),
				tap((meta: any) => {
					return (this.metadata = meta);
				})
			)
			.subscribe();
	}
}
