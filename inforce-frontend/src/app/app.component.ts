import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { Header } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HomeComponent, Header],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'inforce-frontend';
}
