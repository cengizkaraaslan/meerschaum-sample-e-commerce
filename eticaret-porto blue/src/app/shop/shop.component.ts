import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Service/Products.service';
import { Products } from '../model/products';
import { CartService } from '../Service/Cart.service';
import { Options, LabelType } from 'ng5-slider';
import { CategoryService } from '../Service/Category.service';
import { Category } from '../model/category';
import { MotherCategoryService } from '../Service/MotherCategory.service';
import { Undercategory } from '../model/undercategory';
import { Mothercategory } from '../model/mothercategory';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css'],
  providers: [ProductsService]
})
export class ShopComponent implements OnInit {
  constructor(
    private productService: ProductsService,
    private cartservice: CartService,
    private category: CategoryService,
    private mothercategory: MotherCategoryService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.shoplist = window.innerWidth <= 500 ? 1 : 3;

    this.getproductcount();
    this.getCategory();
    this.getMotherCategory();
    this.getproductAlldata();
    this.activatedRoute.queryParams.subscribe(params => {
      if (params.page > 0) {
        this._page = params.page;
        this.undercategoryid = params.undercategoryid;
      } else {
        this._page = 1;
      }
      console.log(params);
    });
  }
  shoplist: number;
  products: Products[];
  categoryes: Category[];
  mothercategoryes: Mothercategory[];
  orderby = 1;
  categoryid = 1;
  undercategoryid = 1;
  mothercategoryid = 1;
  _page: number;
  _totalpage = 0;
  minValue = 0;
  maxValue = 3000;
  options: Options = {
    floor: 0,
    ceil: 3000,
    translate: (value: number, label: LabelType): string => {
      switch (label) {
        case LabelType.Low:
          return '<b>Min price:</b> $' + value;
        case LabelType.High:
          return '<b>Max price:</b> $' + value;
        default:
          return '$' + value;
      }
    }
  };

  getproductAlldata() {
    this.productService
      .getProductAlldata(
        this.minValue,
        this.maxValue,
        this.undercategoryid,
        this.orderby,
        this._page
      )
      .subscribe(res => {
        this.products = res;

        // this.setPage(1);
      });
  }
  onChange(orderbyvalue: number) {
    this.orderby = orderbyvalue;
    this.getproductAlldata();
  }

  getproductcount() {
    this.productService.getProductCount(this.undercategoryid).subscribe(res => {
      this._totalpage = res;
    });
  }
  ngOnInit() {}
  cartadd(pro: Products) {
    this.cartservice.cartadd(pro);
  }
  onSliderChange(selectedValues: number[]) {}
  setPage(page: number) {
    this._page = page;

    if (window.innerWidth > 500) {
      if (window.scrollY > 1000) {
        window.scroll(0, 250);
      }
    }


    // if (this._page ===1) {
    //   this.router.navigate(['/shop'] );
    //   return;
    // }
    this.routernavigate();
    this.getproductAlldata();
  }
  goToLink(url: string) {
    window.open('#/singleproduct/' + url, '_blank');
}
  routernavigate() {
    this.router.navigate(['/shop'], {
      queryParams: { page: this._page, undercategoryid: this.undercategoryid }
    });
  }
  getCategory() {
    this.category.getCategory(this.mothercategoryid).subscribe(res => {
      this.categoryes = res;
    });
  }
  getMotherCategory() {
    this.mothercategory.getCategory().subscribe(res => {
      this.mothercategoryes = res;
    });
  }
  undercategorychanged(categoryitem: Undercategory, categoryindex: number) {
    this.undercategoryid = categoryitem.under_category_id;
    this._page = 1;
    this.getproductAlldata();
    this.getproductcount();
    this.routernavigate();

  }
  mothercategorychanged(categoryitem: Mothercategory, categoryindex: number) {
    this.mothercategoryid = categoryitem.mothercategory_id;
    this.getCategory();
  }
}
