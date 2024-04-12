import { Component, OnInit } from '@angular/core';
import { LoggingService } from './logging/logging.service';

@Component({
  selector: 'valant-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less'],
})
export class AppComponent implements OnInit {
  public title = 'Valant demo';

  constructor(private logger: LoggingService) {}

  async ngOnInit() {
    this.logger.log('Welcome to the AppComponent');
  }
}
