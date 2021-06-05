import { Component, Input } from '@angular/core';
import { MatchVm } from '@app/web-api-client';

@Component({
	selector: 'e21b-match-list',
	templateUrl: './match-list.component.html',
	styleUrls: ['./match-list.component.scss']
})
export class MatchListComponent {

	@Input() public matches: MatchVm[] = [];
	// @Input() public isLoading = true;

}
