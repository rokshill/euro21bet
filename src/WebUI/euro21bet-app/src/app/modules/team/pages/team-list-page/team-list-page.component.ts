import { Component, OnInit } from '@angular/core';
import { TeamClient, TeamDto } from '@app/web-api-client';
import { Observable } from 'rxjs';

@Component({
	selector: 'e21b-team-list-page',
	templateUrl: './team-list-page.component.html',
	styleUrls: ['./team-list-page.component.scss']
})
export class TeamListPageComponent implements OnInit {
	public teams$!: Observable<TeamDto[]>;

	constructor(
		private client: TeamClient
	) { }

	public ngOnInit(): void {
		this.teams$ = this.client.getAll();
	}
}
