import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TenantHomepageComponent } from './tenant-homepage.component';

describe('TenantHomepageComponent', () => {
  let component: TenantHomepageComponent;
  let fixture: ComponentFixture<TenantHomepageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantHomepageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantHomepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
