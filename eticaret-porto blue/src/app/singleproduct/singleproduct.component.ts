import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Service/Products.service';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { Products } from '../model/products';
import { CartService } from '../Service/Cart.service';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation
} from 'ngx-gallery';
import { Photo } from '../model/Photo';
import { Category } from '../model/category';

@Component({
  selector: 'app-singleproduct',
  templateUrl: './singleproduct.component.html',
  styleUrls: ['./singleproduct.component.css'],
  providers: [ProductsService]
})
export class SingleproductComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private productservice: ProductsService,
    private cartservice: CartService,
    private router: Router
  ) {}

  product: Products;
  productlist: Products[];
  // productmodel: ProductModel;
  photos: Photo[] = [];
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  category: Category;
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.GetPhotosByProduct(params['productid']);
      this.GetByProcutId(params['productid']);
      this.getproduct();
      window.scroll(0, 30);
    });
    this.router.events.subscribe((evt) => {
      if (!(evt instanceof NavigationEnd)) {
          return;
      }
      window.scrollTo(0, 0);
  });
  }
  GetByProcutId(productid) {
    this.productservice.getProductById(productid).subscribe(data => {
      this.product = data;

    });
  }
  getproduct() {

    this.productservice
      .recentlyViewed()
      .subscribe(res => {
        this.productlist = res;

        // this.setPage(1);
      });
  }
  getImages() {
    // tslint:disable-next-line:no-debugger
    const imageurl = [];
    for (let i = 0; i < this.photos.length; i++) {
      imageurl.push({
        small: this.photos[i].url,
        medium: this.photos[i].url,
        big: this.photos[i].url
      });
    }
    return imageurl;
  }

  GetPhotosByProduct(productid) {
    this.productservice.getPhotoById(productid).subscribe(data => {
      this.photos = data;
      this.SetGallery();
    });
  }
  SetGallery() {
    this.galleryOptions = [
      {
        width: '100%',
        height: '400px',
        thumbnailsColumns: 4,
        imageAutoPlay: true,
        imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnailsPercent: 20,
        thumbnailsMargin: 20,
        thumbnailMargin: 20
      },
      // max-width 400
      {
        breakpoint: 400,
        preview: true
      }
    ];
    this.galleryImages = this.getImages();
  }
  cartadd(pro: Products) {
    this.cartservice.cartadd(pro);
  }

}
