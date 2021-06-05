import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { RoundVm } from '@app/web-api-client';

@Component({
	selector: 'e21b-round-list',
	templateUrl: './round-list.component.html',
	styleUrls: ['./round-list.component.scss'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class RoundListComponent {

	@Input() public rounds: RoundVm[] = [];
	@Input() public isLoading = true;

	// public trackById: TrackByFunction<RoundVm> = (_, item) => item.id;

}
