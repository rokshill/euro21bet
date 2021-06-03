import { Component, OnInit } from '@angular/core';
import { MatchClient, MatchesPageVm } from '@app/web-api-client';
import { Observable } from 'rxjs';

@Component({
	selector: 'e21b-matches-page',
	templateUrl: './match-list-page.component.html',
	styleUrls: ['./match-list-page.component.scss']
})
export class MatchListPageComponent implements OnInit {
	public matches$!: Observable<MatchesPageVm>;

	constructor(private matchService: MatchClient) { }

	public ngOnInit(): void {
		this.matches$ = this.matchService.getAll();
	}
}
