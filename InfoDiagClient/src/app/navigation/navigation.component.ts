import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver,
              private authService: AuthenticationService,
              private router: Router) {}

  redirect(link: string, id: number | undefined) {
    if (id) {
      this.router.navigate([link, id]);
    } else {
      this.router.navigate([link]);
    }
  }

  click(sideNav: any) {
    // hack to make the drawer work... 
    sideNav._drawers.first.toggle()
  }

  logout() {
    this.authService.logout();
    location.reload();
  }

  isConnected() {
    return !!this.authService.currentUserValue;
  }
}
