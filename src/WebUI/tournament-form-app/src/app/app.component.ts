import { Component, OnInit } from "@angular/core";
import { PrimeNGConfig } from "primeng/api";

@Component({
	selector: "roksh-root",
	templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
	public title = "tournament-form-app";

	constructor(private primengConfig: PrimeNGConfig) {}

	public ngOnInit(): void {
		this.primengConfig.ripple = true;
	}
}
