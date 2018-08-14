//index.js
//获取应用实例
const app = getApp()

Page({
  data: {
   motto: 'Hello World',
    userInfo: {},
    hasUserInfo: false,
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    first_line:"hello",
    zero:0,
    array:[{
      "first":1
    },{
      "two":2
    }],
    imgUrls: [
      'https://tse4-mm.cn.bing.net/th?id=OIP.03IjMVKOjC-A4LNcvD3ETgHaEo&w=300&h=187&c=7&o=5&dpr=1.25&pid=1.7',
      'https://tse4-mm.cn.bing.net/th?id=OIP.GgHKeE74Av7-kfDsw-st5AHaJ4&w=128&h=169&c=7&o=5&dpr=1.25&pid=1.7',
      'https://tse4-mm.cn.bing.net/th?id=OIP.SXTuURqaBv1691bRbA1GnwHaEc&w=295&h=174&c=7&o=5&dpr=1.25&pid=1.7'
    ],
    
    items: [
      { value: '海贼王', checked: 'true' },
      {  value: '一人之下' },
      {  value: '秦时明月' },
      {  value: '火影' },
      {  value: '柯南' },
      { value: '熊出没' },
      { value: '千与千寻' },
    ],
    multiArray: [['宫崎骏', '沈月平','尾田','岸本'], ['热血', '冒险', '文艺', '爱情', '悬疑'], ['日漫', '国漫','欧美']],
    multiIndex: [0, 0, 0],
    
  },
  //事件处理函数
  bindViewTap: function() {
    wx.navigateTo({
      url: '../logs/logs'
    })
  },
  onLoad: function () {
    if (app.globalData.userInfo) {
      this.setData({
        userInfo: app.globalData.userInfo,
        hasUserInfo: true
      })
    } else if (this.data.canIUse){
      // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
      // 所以此处加入 callback 以防止这种情况
      app.userInfoReadyCallback = res => {
        this.setData({
          userInfo: res.userInfo,
          hasUserInfo: true
        })
      }
    } else {
      // 在没有 open-type=getUserInfo 版本的兼容处理
      wx.getUserInfo({
        success: res => {
          app.globalData.userInfo = res.userInfo
          this.setData({
            userInfo: res.userInfo,
            hasUserInfo: true
          })
        }
      })
    }
  },
  getUserInfo: function(e) {
    console.log(e)
    app.globalData.userInfo = e.detail.userInfo
    this.setData({
      userInfo: e.detail.userInfo,
      hasUserInfo: true
    })
  },
  getPhoneNumber: function(e) {
  console.log(e.detail.errMsg) 
  console.log(e.detail.iv) 
  console.log(e.detail.encryptedData)
  } 
})
