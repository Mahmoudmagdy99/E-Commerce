import { Component} from '@angular/core';
import { HeaderComponent } from "./layout/header/header.component";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-root',
  //imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [HeaderComponent, RouterOutlet],
})
export class AppComponent {
  
  title = 'Skinet';
}
