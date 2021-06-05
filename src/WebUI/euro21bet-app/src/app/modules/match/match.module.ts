import { NgModule } from '@angular/core';
import { SharedModule } from '@app/shared/shared.module';
import { MatchRoutingModule } from './match-routing.module';
import { MatchComponent as MatchComponent } from './match.component';
import { MatchListPageComponent } from './pages/match-list-page/match-list-page.component';
import { RoundListComponent } from './components/round-list/round-list.component';
import { MatchListComponent } from './components/match-list/match-list.component';


@NgModule({
	declarations: [
		MatchComponent,
		MatchListPageComponent,
  RoundListComponent,
  MatchListComponent
	],
	imports: [
		SharedModule,
		MatchRoutingModule,
	]
})
export class MatchModule { }
