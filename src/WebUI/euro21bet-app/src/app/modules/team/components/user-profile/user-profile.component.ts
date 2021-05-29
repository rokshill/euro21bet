import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
	selector: 'e21b-user-profile',
	template: `
    <div *ngIf="auth.user$ | async as user">
      <ul>
        <li>{{ user.name }}</li>
        <li>{{ user.email }}</li>
      </ul>
      <pre>{{user | json}}</pre>
    </div>`
})
export class UserProfileComponent {
	constructor(public auth: AuthService) {}
}
