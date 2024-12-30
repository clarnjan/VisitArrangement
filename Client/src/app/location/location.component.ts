import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.scss']
})
export class LocationComponent implements OnInit {
  @Input()public locationName: string = '';
  @Input()public locationImages: string[] = [];
  public displayedImages: string[] = [];

  currentSlide: number = 0;

  ngOnInit(): void {
    this.displayedImages = this.locationImages;
    if (this.locationImages.length > 1) {
      this.currentSlide = 1;
    }
  }

  public shiftLeft(): void {
      if (this.locationImages.length === 0)
        return;
      const firstElement = this.locationImages.shift();
      this.locationImages.push(firstElement!);
  }

  public shiftRight(): void {
    if (this.locationImages.length === 0)
      return;
    const lastElement = this.locationImages.pop();
    this.locationImages.unshift(lastElement!);
  }
}
