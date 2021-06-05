import { Component, OnInit } from '@angular/core';
import { MatchClient, MatchesPageVm, RoundVm } from '@app/web-api-client';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
	selector: 'e21b-matches-page',
	templateUrl: './match-list-page.component.html',
	styleUrls: ['./match-list-page.component.scss']
})
export class MatchListPageComponent implements OnInit {
	public rounds$: Observable<RoundVm[]>;
	public isLoading: BehaviorSubject<boolean> = new BehaviorSubject(true);

	constructor(private matchService: MatchClient) { }

	public ngOnInit(): void {
		this.rounds$ = this.matchService.getAll().pipe(
			tap(() => this.isLoading.next(true)),
			map((data: MatchesPageVm) => {
				return data.rounds ? data.rounds : [];
			}),
			tap(() => this.isLoading.next(false)),
		);
	}
}
