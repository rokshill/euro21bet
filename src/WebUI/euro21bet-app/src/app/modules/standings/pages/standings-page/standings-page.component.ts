import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { StandingsClient, StandingsPageVm } from '@app/web-api-client';
import { Observable } from 'rxjs';

@Component({
	selector: 'e21b-standings-page',
	templateUrl: './standings-page.component.html',
	styleUrls: ['./standings-page.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class StandingsPageComponent implements OnInit {
	public standings$!: Observable<StandingsPageVm>;

	constructor(private standingsService: StandingsClient) { }

	public ngOnInit(): void {
		this.standings$ = this.standingsService.getAll();
	}
}
