import { Injector } from '@angular/core';

export class AppInjector {

	public static injector: Injector;

	public static getInjector(): Injector {
		return this.injector;
	}

	public static setInjector(injector: Injector): void {
		this.injector = injector;
	}
}
